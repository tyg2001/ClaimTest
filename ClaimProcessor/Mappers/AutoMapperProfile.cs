using ClaimProcessor.DTOs;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.AccessControl;
using System.Security.Principal;
using ClaimProcessor.Models;
using AutoMapper;

namespace ClaimProcessor.Mappers
{
    
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Claim, ClaimDTO>()
                    .ReverseMap();
                CreateMap<DrugPrice, DrugPriceDTO>()
                    .ReverseMap();

        }
        }

    }

