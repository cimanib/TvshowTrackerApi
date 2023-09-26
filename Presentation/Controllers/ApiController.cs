using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{

	[ApiController]
    public abstract class ApiController : ControllerBase
    {
		protected readonly ISender Sender;

		public ApiController(ISender sender)
		{
			this.Sender = sender;
		}
	}
}

