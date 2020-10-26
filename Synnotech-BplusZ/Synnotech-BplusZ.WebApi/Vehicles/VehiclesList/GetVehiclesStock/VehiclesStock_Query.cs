using Raven.Client.Documents.Indexes;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class VehiclesStock_Query : AbstractIndexCreationTask<Vehicle>
    {
        public VehiclesStock_Query()
        {
            Map = vehicles => vehicles.Select(vehicle => new VehicleStockSearchIndexResult
            {
                LicenceNumber = vehicle.GeneralData!.LicenceNumber,
                BranchOffice = vehicle.TransferData!.BranchOffice,
                Manufacturer = vehicle.GeneralData!.Manufacturer,
                Model = vehicle.GeneralData!.Model,
                Status = vehicle.GeneralData!.Status,
                ConstructionType = vehicle.TechnicalComponents!.ConstructionType,
                Type = vehicle.GeneralData!.Type,
                DeleteDate = vehicle.DeleteDate,
                VehicleClass = vehicle.GeneralData!.VehicleClass,
                Query = new List<string>
                {
                    vehicle.GeneralData!.Manufacturer ?? string.Empty,
                    vehicle.GeneralData!.Model ?? string.Empty,
                    vehicle.TransferData!.BranchOffice ?? string.Empty,
                }
            });

            Index("Query", FieldIndexing.Search);
        }
    }
}
