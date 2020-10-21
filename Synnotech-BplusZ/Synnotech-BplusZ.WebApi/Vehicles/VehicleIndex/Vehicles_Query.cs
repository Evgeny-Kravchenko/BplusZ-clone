using Raven.Client.Documents.Indexes;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleIndex;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles
{
    public class Vehicles_Query : AbstractIndexCreationTask<Vehicle>
    {
        public Vehicles_Query()
        {
            Map = vehicles => vehicles.Select(vehicle => new VehicleSearchIndexResult
            {
                LicenceNumber = vehicle.LicenceNumber,
                BranchOffice = vehicle.TransferData!.BranchOffice,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Status = vehicle.StatusData!.Status,
                ConstructionType = vehicle.TechnicalComponents!.ConstructionType,
                Type = vehicle.StatusData.Type,
                DeleteDate = vehicle.DeleteDate,
                State = vehicle.StatusData.State,
                Query = new List<string>
                {
                    vehicle.Manufacturer ?? string.Empty,
                    vehicle.TechnicalComponents!.ConstructionType ?? string.Empty,
                    vehicle.Model ?? string.Empty,
                    vehicle.TransferData!.BranchOffice ?? string.Empty,
                }
            });

            Index("Query", FieldIndexing.Search);
        }
    }
}
