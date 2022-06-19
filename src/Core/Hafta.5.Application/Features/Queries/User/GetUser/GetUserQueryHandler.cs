using Hafta._5.Domain.Entities.Identity;
using Hafta._5.Domain.Entities.Paging;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta._5.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private UserManager<AppUser> _userManager;

        public GetUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {

            //UserManger ile kullanıcılarımızın listesini alıyoruz.
            IQueryable<AppUser> Users = _userManager.Users;
            if (!string.IsNullOrEmpty(request.SearchByName))
            {
                Users = Users.Where(x => x.City.Contains(request.SearchByName));
            }

            if (!string.IsNullOrEmpty(request.SearchByCity))
            {
                Users = Users.Where(x => x.City.Contains(request.SearchByCity));
            }

            if (request.AgeRangeCeiling != 0 || request.AgeRangeLower != 0 )
            {
                if (request.AgeRangeCeiling == 0) request.AgeRangeCeiling = 120;
                Users = Users.Where(x => x.Age < request.AgeRangeCeiling && x.Age > request.AgeRangeLower);
            }



            int TotalUser = Users.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;
            MetaPageInfo metaPageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                Limit = request.Limit,
                Page = request.Page,
                HasNext = request.Page == TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };
            //Response nesnemizi oluşturup içine gerekli bilgileri giriyoruz.
            GetUserQueryResponse response = new()
            {
                AppUsers = Users.Skip(Skip).Take(request.Limit),
                MetaPageInfo = metaPageInfo,
            };
            if (!response.AppUsers.Any())
            {
                throw new Exception("User not found");
            }
            return Task.FromResult(response);

        }

       
    }
}
