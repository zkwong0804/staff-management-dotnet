using StaffManagement.Model;

namespace StaffManagement.DataTransfer.Mapper
{
    public interface IMapper<T, TResponse> where T : BaseModel
        where TResponse : BaseResponse
    {
        public T MapRequestToModel(BaseRequest request);
        public TResponse MapModelToResponse(T model);
        public EnumerableResponse<TResponse> MapModelToResponse(IEnumerable<T> models, 
            int skip, int take, int total, string query);
    }
}
