using AutoMapper;
using WorkShake.Models;
using WorkShake.Models.DTO;

namespace Utils
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<ChainStore, ChainStoreSimpleDTO>();
      CreateMap<ChainStore, ChainStoreWithStoreDTO>();

      CreateMap<Store, StoreSimpleDTO>();
      CreateMap<Store, StoreWithoutChainStoreDTO>();

      CreateMap<User, UserSimpleDTO>();
    }
  }
}
