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
                LicenceNumber = vehicle.GeneralData!.LicenceNumber,
                BranchOffice = vehicle.TransferData!.BranchOffice,
                Manufacturer = vehicle.GeneralData!.Manufacturer,
                Model = vehicle.GeneralData!.Model,
                ConstructionType = vehicle.TechnicalComponents!.ConstructionType,
                DeleteDate = vehicle.DeleteDate,
                State = vehicle.GeneralData!.State,
                VehicleClass = vehicle.GeneralData!.VehicleClass,
                NumberOfInvestment = vehicle.GeneralData!.NumberOfInvestment,
                Query = new List<string>
                {
                    vehicle.GeneralData!.Manufacturer ?? string.Empty,
                    vehicle.TechnicalComponents!.ConstructionType ?? string.Empty,
                    vehicle.GeneralData!.Model ?? string.Empty,
                    vehicle.TransferData!.BranchOffice ?? string.Empty,
                }
            });

            Index("Query", FieldIndexing.Search);
        }
    }
}
