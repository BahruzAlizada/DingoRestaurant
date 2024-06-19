using Dingo.Application.Abstracts;
using Dingo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.UI.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialMediaReadRepository socialMediaReadRepository;
        private readonly IInfoReadRepository infoReadRepository;
        public FooterViewComponent(ISocialMediaReadRepository socialMediaReadRepository,IInfoReadRepository infoReadRepository)
        {
            this.socialMediaReadRepository = socialMediaReadRepository;
            this.infoReadRepository = infoReadRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footerVM = new FooterVM
            {
                SocialMedias = await socialMediaReadRepository.GetCachingActiveSocialMediasAsync(),
                Info = await infoReadRepository.GetCachingInfoAsync()
            };

            return View(footerVM);
        }
    }
}
