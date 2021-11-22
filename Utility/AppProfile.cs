using MyApplication.Models;
using MyApplication.Models.ModelDbContext;
using MyApplication.VeiwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Utility
{
    public class AppProfile : AutoMapper.Profile
    {
        public AppProfile()
        {
            CreateMap<Staffs, staffsViewModel>()
                .ReverseMap();

            CreateMap<Staffs, StaffViewModel>()
                .ReverseMap();
            CreateMap<Staffs, staffUpdateViewModel>()
                .ReverseMap();
           // CreateMap<staffs, DepartmentViewModel>()
          //      .ReverseMap();
            CreateMap<CashAdvance, CashAdvanceViewModel>()
                .ReverseMap();
            CreateMap<Visitor, VisitorViewModel>()
                .ReverseMap();
            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
        }
    }
}
