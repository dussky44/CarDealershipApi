using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Model;
using OrderApi.Services;

namespace OrderApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {

        private MailingService _mailingService = new MailingService();

        [HttpPost]
        public async Task<IActionResult> LoginAsync(KafkaOrderRequest request) {
            await _mailingService.Execute(request);
            return Ok(true);
        }
    }
}
