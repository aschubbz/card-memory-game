using AutoMapper;
using Base.Model.Card;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Maping
{
    public class GameCardMappingProfile : Profile
    {
        public GameCardMappingProfile() {
            CreateMap<Card, CardViewModel>();
        }
    }
}
