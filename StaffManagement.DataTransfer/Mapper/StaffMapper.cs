using StaffManagement.DataTransfer.Department;
using StaffManagement.DataTransfer.Staff;
using System.Reflection;

namespace StaffManagement.DataTransfer.Mapper
{
    public class StaffMapper : IMapper<Model.Staff, StaffResponse>
    {
        public EnumerableResponse<StaffResponse> MapModelToResponse
            (IEnumerable<Model.Staff> models, int skip, int take, 
            int total, string query)
        {
            return new EnumerableResponse<StaffResponse>()
            {
                Responses = models.Select(x => new StaffResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Department = new()
                    {
                        Id = x.Department.Id,
                        Name = x.Department.Name
                    }
                }),
                Skip = skip,
                Take = take,
                Total = total,
                Query = query
            };
        }

        public StaffResponse MapModelToResponse(Model.Staff model)
        {
            return new StaffResponse()
            {
                Id = model.Id,
                Name = model.Name,
                Department = new() { Id = model.Department.Id, Name = model.Department.Name }
            };
        }

        public Model.Staff MapRequestToModel(BaseRequest request)
        {
            switch (request)
            {
                case StaffCreateRequest:
                    var createRequest = request as StaffCreateRequest;
                    return new Model.Staff()
                    {
                        Name = createRequest.Name,
                        DepartmentID = createRequest.departmentId
                    };
                case StaffUpdateRequest:
                    var updateRequest = request as StaffUpdateRequest;
                    return new Model.Staff()
                    {
                        Name = updateRequest.Name,
                        DepartmentID = updateRequest.departmentId
                    };
                default:
                    return null;
            }
        }
    }
}
