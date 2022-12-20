using StaffManagement.DataTransfer.Department;

namespace StaffManagement.DataTransfer.Mapper
{
    public class DepartmentMapper : IMapper<Model.Department, DepartmentResponse>
    {
        public DepartmentResponse MapModelToResponse(Model.Department model)
        {
            return new DepartmentResponse()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public EnumerableResponse<DepartmentResponse> MapModelToResponse(IEnumerable<Model.Department> models, int skip, int take, int total, string query)
        {
            return new EnumerableResponse<DepartmentResponse>()
            {
                Responses = models.Select(x => new DepartmentResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                }),
                Take = take,
                Skip = skip,
                Total = total,
                Query = query
            };
        }

        public Model.Department MapRequestToModel(BaseRequest request)
        {
            switch (request)
            {
                case DepartmentCreateRequest:
                    return new Model.Department()
                    {
                        Name = request.Name
                    };
                case DepartmentUpdateRequest:
                    return new Model.Department()
                    {
                        Name = request.Name
                    };
                default:
                    return null;
            }
        }
    }
}
