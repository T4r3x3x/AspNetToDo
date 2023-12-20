using ApplicationCore.Models;
using AutoMapper;
using DAL.Entities;
using Representation.Models.UserModels;
using System;

namespace Representation
{
    public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<SignUpViewModel, SignUpModel>();
			CreateMap<SignUpModel, User>();
		}
	}
}
