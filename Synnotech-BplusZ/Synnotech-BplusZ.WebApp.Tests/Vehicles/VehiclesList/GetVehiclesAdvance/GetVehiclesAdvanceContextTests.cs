using Raven.Client.Documents.Session;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance;
using Synnotech_BplusZ.WebApp.Tests.TestHelpers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class GetVehiclesAdvanceContextTests : RavenDbTest
    {
        private readonly GetVehiclesAdvanceContext _context;
        private readonly IAsyncDocumentSession _asyncDocumentSession;

        public GetVehiclesAdvanceContextTests()
        {
            _asyncDocumentSession = _documentStore.OpenAsyncSession();
            _context = new GetVehiclesAdvanceContext(_asyncDocumentSession);
        }

        [Fact]
        public async Task GetVehicles_WithDefaultOptions_ReturnsAdvancevehicles()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context. GetVehiclesAdvance(new GetVehiclesAdvancedDto());
            Assert.True(response.Result.All(v => v.GeneralData.Status.Equals(VehicleStatuses.Advance)));
        }

        [Fact]
        public async Task GetVehicles_WithSortingOptionAscending_ReturnsRightSorting()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SortField = nameof(VehicleAdvanceSearchIndexResult.Model),
            });

            var first = response.Result.First();
            var last = response.Result.Last();
            Assert.StartsWith("A", first.GeneralData.Model);
            Assert.StartsWith("C", last.GeneralData.Model);
        }

        [Fact]
        public async Task GetVehicles_WithSortingOptionDescnding_ReturnsRightSorting()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SortField = nameof(VehicleAdvanceSearchIndexResult.Model),
                IsAscendingSortOrder = false
            });

            var first = response.Result.First();
            var last = response.Result.Last();
            Assert.StartsWith("C", first.GeneralData.Model);
            Assert.StartsWith("A", last.GeneralData.Model);
        }

        [Fact]
        public async Task GetVehicles_WithSkip0Take2_ReturnsTwoItems()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                Skip = 0,
                Take = 2
            });

            Assert.Equal(3, response.Count);
            Assert.Equal(2, response.Result.Count());
        }

        [Fact]
        public async Task GetVehicles_WithSkip2Take2_ReturnsOneItem()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                Skip = 2,
                Take = 2
            });

            Assert.Equal(3, response.Count);
            Assert.Single(response.Result);
        }

        [Fact]
        public async Task GetVehicles_GlobalSearch_ReturnsRightVehicle()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var model = "Ctego";
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SearchTerm = model
            });

            Assert.Single(response.Result);
            Assert.Equal(model, response.Result.First().GeneralData.Model);
        }

        [Fact]
        public async Task GetVehicles_GlobalSearchCaseNonSensitivityCheck_ReturnsRightVehicle()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var model = "ctEgo";
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SearchTerm = model
            });

            Assert.Single(response.Result);
            Assert.Equal("Ctego", response.Result.First().GeneralData.Model);
        }

        [Fact]
        public async Task GetVehicles_GlobalSearchNotCompleteMatchCheck_ReturnsRightVehicle()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var model = "teg";
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SearchTerm = model
            });

            Assert.True(response.Result.All(v => v.GeneralData.Model.Contains(model)));
        }

        [Fact]
        public async Task GetVehicles_LicenseNumberSearch_ReturnsRightVehicle()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var licenseNumber = "B LL 99";
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SearchTerm = licenseNumber,
                SearchField = "licenseNumber"
            });

            Assert.Single(response.Result);
            Assert.Equal(licenseNumber, response.Result.First().GeneralData.LicenseNumber);
        }

        [Fact]
        public async Task GetVehicles_InvestmentNumberSearch_ReturnsRightVehicle()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var numberOfInvestment = "BZ-BZ-101";
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                SearchTerm = numberOfInvestment,
                SearchField = "numberOfInvestment"
            });

            Assert.Single(response.Result);
            Assert.Equal(numberOfInvestment, response.Result.First().GeneralData.NumberOfInvestment);
        }

        [Fact]
        public async Task GetVehicles_SearchByAllowedStates_ReturnsRightVehicles()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var states = new[] { "Bedarfsanalyse" };
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                AllowedStates = states.ToList()
            });

            Assert.True(response.Result.All(v => states.Contains(v.GeneralData.State)));
        }

        [Fact]
        public async Task GetVehicles_SearchByVehicleClasses_ReturnsRightVehicles()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var classes = new[] { "LKW" };
            var response = await _context.GetVehiclesAdvance(new GetVehiclesAdvancedDto
            {
                AllowedVehicleClasses = classes.ToList()
            });

            Assert.True(response.Result.All(v => classes.Contains(v.GeneralData.VehicleClass)));
        }

        private async Task InitializeDbData()
        {
            await _asyncDocumentSession.StoreAsync(new Vehicle
            {
                GeneralData = new GeneralData
                {
                    LicenseNumber = "B LL 95",
                    NumberOfInvestment = "BZ-BZ-100",
                    Manufacturer = "Mercedes-Benz",
                    Model = "Ctego",
                    Status = "Vorlauf",
                    State = "Bedarfsanalyse",
                    Type = "Mietfahrzeug",
                    VehicleClass = "LKW",
                },
                TechnicalComponents = new TechnicalComponents
                {
                    ConstructionType = "BDF"
                },
                TransferData = new TransferData
                {
                    BranchOffice = "Local Logistik GmbH"
                },
                Finance = new Finance(),
                TechnicalContractData = new TechnicalContractData(),
            });

            await _asyncDocumentSession.StoreAsync(new Vehicle
            {
                GeneralData = new GeneralData
                {
                    LicenseNumber = "B LL 99",
                    NumberOfInvestment = "BZ-BZ-101",
                    Manufacturer = "Mercedes-Benz",
                    Model = "Atego",
                    Status = "Vorlauf",
                    State = "Angebotsphase",
                    Type = "Mietfahrzeug",
                    VehicleClass = "PKW",
                },
                TechnicalComponents = new TechnicalComponents
                {
                    ConstructionType = "BDF"
                },
                TransferData = new TransferData
                {
                    BranchOffice = "Local Logistik GmbH"
                },
                Finance = new Finance(),
                TechnicalContractData = new TechnicalContractData(),
            });

            await _asyncDocumentSession.StoreAsync(new Vehicle
            {
                GeneralData = new GeneralData
                {
                    LicenseNumber = "B LL 97",
                    NumberOfInvestment = "BZ-BZ-102",
                    Manufacturer = "Mercedes-Benz",
                    Model = "Btego",
                    Status = "Vorlauf",
                    State = "Angebotsphase",
                    Type = "Mietfahrzeug",
                    VehicleClass = "PKW",
                },
                TechnicalComponents = new TechnicalComponents
                {
                    ConstructionType = "BDF"
                },
                TransferData = new TransferData
                {
                    BranchOffice = "Local Logistik GmbH"
                },
                Finance = new Finance(),
                TechnicalContractData = new TechnicalContractData(),
            });

            await _asyncDocumentSession.StoreAsync(new Vehicle
            {
                GeneralData = new GeneralData
                {
                    LicenseNumber = "B LL 96",
                    NumberOfInvestment = "BZ-BZ-103",
                    Manufacturer = "Mercedes-Benz",
                    Model = "Btego",
                    Status = "Aerkstatt",
                    State = "",
                    Type = "Mietfahrzeug",
                    VehicleClass = "LKW",
                },
                TechnicalComponents = new TechnicalComponents
                {
                    ConstructionType = "BDF"
                },
                TransferData = new TransferData
                {
                    BranchOffice = "Local Logistik GmbH"
                },
                Finance = new Finance(),
                TechnicalContractData = new TechnicalContractData(),
            });

            await _asyncDocumentSession.SaveChangesAsync();
        }
    }
}
