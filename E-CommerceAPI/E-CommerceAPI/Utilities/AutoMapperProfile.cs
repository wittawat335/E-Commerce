using AutoMapper;
using E_CommerceAPI.Entities;
using E_CommerceAPI.ViewModels;

namespace E_CommerceAPI.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            //mapping
            #region ProductCategory
            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
            #endregion
            #region User
            CreateMap<User, UserViewModel>();
            #endregion
            //#region Product
            //CreateMap<Product, ProductDTO>().ForAllMembers(destiny => destiny.);
            //#endregion
            CreateMap<UserViewModel, User>();
            CreateMap<ProductCategoryViewModel, ProductCategory>();
        }
    }
}
