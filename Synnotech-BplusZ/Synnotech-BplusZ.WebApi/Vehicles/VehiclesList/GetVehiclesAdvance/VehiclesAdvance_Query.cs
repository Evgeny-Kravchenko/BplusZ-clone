using Raven.Client.Documents.Indexes;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class VehiclesAdvance_Query : AbstractIndexCreationTask<Vehicle>
    {
        public VehiclesAdvance_Query()
        {
            Map = vehicles => vehicles.Select(vehicle => new VehicleAdvanceSearchIndexResult
            {
                LicenceNumber = vehicle.LicenceNumber,
                BranchOffice = vehicle.TransferData!.BranchOffice,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                ConstructionType = vehicle.TechnicalComponents!.ConstructionType,
                DeleteDate = vehicle.DeleteDate,
                State = vehicle.State,
                VehicleClass = vehicle.VehicleClass,
                NumberOfInvestment = vehicle.NumberOfInvestment,
                Query = new List<string>
                {
                    vehicle.Manufacturer ?? string.Empty,
                    vehicle.TechnicalComponents!.ConstructionType ?? string.Empty,
                    vehicle.Model ?? string.Empty,
                    vehicle.TransferData!.BranchOffice ?? string.Empty,
                    vehicle.TechnicalComponents!.ConstructionType ?? string.Empty,
                    vehicle.VehicleClass ?? string.Empty,
                    vehicle.NumberOfInvestment ?? string.Empty,
                }
            });

            Index("Query", FieldIndexing.Search);
        }
    }
}
