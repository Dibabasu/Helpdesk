using AutoMapper;

namespace Helpdesk.Model.Common.AutoMapper.Interface
{
    public interface IHaveCustomMapping<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}