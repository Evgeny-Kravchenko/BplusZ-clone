using Raven.Client.Documents.Session;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock;
using Synnotech_BplusZ.WebApp.Tests.TestHelpers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehiclesList.GetVehiclesStock
{
    public class GetVehicleStockContextTests : RavenDbTest
    {
        private readonly GetVehiclesStockContext _context;
        private readonly IAsyncDocumentSession _asyncDocumentSession;

        public GetVehicleStockContextTests()
        {
            _asyncDocumentSession = _documentStore.OpenAsyncSession();
            _context = new GetVehiclesStockContext(_asyncDocumentSession);
        }

        [Fact]
        public async Task GetVehicles_WithDefaultOptions_ReturnsStockvehicles()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context.GetStockVehicles(new GetVehiclesStockDto());
            Assert.True(response.Result.All(v => !v.GeneralData.Status.Equals(VehicleStatuses.Advance)));
        }

        [Fact]
        public async Task GetVehicles_WithSortingOptionAscending_ReturnsRightSorting()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
            {
                SortField = nameof(VehicleStockSearchIndexResult.Model),
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

            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
            {
                SortField = nameof(VehicleStockSearchIndexResult.Model),
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

            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
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

            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
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
            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
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
            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
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
            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
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
            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
            {
                 SearchTerm = licenseNumber,
                 SearchField = "licenseNumber"
            });

            Assert.Single(response.Result);
            Assert.Equal(licenseNumber, response.Result.First().GeneralData.LicenseNumber);
        }

        [Fact]
        public async Task GetVehicles_SearchByAllowedStatuses_ReturnsRightVehicles()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var statuses = new[] { "Aerkstatt" };
            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
            {
                AllowedStatuses = statuses.ToList()
            });

            Assert.True(response.Result.All(v => statuses.Contains(v.GeneralData.Status)));
        }

        [Fact]
        public async Task GetVehicles_SearchByVehicleClasses_ReturnsRightVehicles()
        {
            await ApplyMigrations();
            await InitializeDbData();

            var classes = new[] { "LKW" };
            var response = await _context.GetStockVehicles(new GetVehiclesStockDto
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
                    Manufacturer = "Mercedes-Benz",
                    Model = "Ctego",
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

            await _asyncDocumentSession.StoreAsync(new Vehicle
            {
                GeneralData = new GeneralData
                {
                    LicenseNumber = "B LL 99",
                    Manufacturer = "Mercedes-Benz",
                    Model = "Atego",
                    Status = "Werkstatt",
                    State = "",
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
                    Manufacturer = "Mercedes-Benz",
                    Model = "Btego",
                    Status = "Aerkstatt",
                    State = "",
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
                    Manufacturer = "Mercedes-Benz",
                    Model = "Btego",
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

            await _asyncDocumentSession.SaveChangesAsync();
        }
    }
}
