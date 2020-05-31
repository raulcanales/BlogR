using BlogR.Core.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogR.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Index()
        {
            var rnd = new Random();

            for (var i = 0; i < 50; i++)
            {
                await _mediator.Send(new RegisterUserCommand
                {
                    Email = $"user{i}@test.com",
                    Nickname = $"User {i}",
                    Password = "123456"
                });
            }

            for (var i = 0; i < 400; i++)
            {
                await _mediator.Send(new CreatePostCommand
                {
                    AuthorId = rnd.Next(1, 49),
                    Title = $"Post #{i}",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                    Content = "Donec non interdum tellus. Donec egestas quam eu purus bibendum pharetra. Duis eu tortor at nibh sodales aliquet non vel ante. Duis id elementum augue. Suspendisse pulvinar gravida pretium. Aenean faucibus egestas lacus, vitae semper dolor vehicula consequat. Nulla et orci et augue efficitur aliquam. Donec tempus, est nec hendrerit viverra, orci mi rutrum turpis, posuere pellentesque velit lectus ut purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi blandit, lectus id pulvinar pretium, orci lorem tristique mi, a venenatis nunc sem id sem. Etiam finibus suscipit arcu, non condimentum justo malesuada non.Donec eget laoreet diam,                    sit amet cursus neque.Etiam tempor eget sem ac malesuada.Cras feugiat sollicitudin ultricies.Suspendisse suscipit odio tellus,                    non porttitor nunc ullamcorper vitae.Sed nisl arcu,                    suscipit et convallis id,                    accumsan quis ligula.Vestibulum est enim,                    efficitur a facilisis dictum,                    tristique non elit.Suspendisse potenti.Nullam fringilla nisl nec sem condimentum,                    id faucibus massa interdum.Nam sapien ipsum,                    pharetra a felis non,                    vehicula condimentum diam.Sed auctor accumsan quam convallis cursus.Donec aliquet viverra neque,                    a elementum ex facilisis a.Donec faucibus feugiat massa a pretium.<br/>< br />Curabitur ut posuere felis,                    id euismod risus.Integer vestibulum,                    diam ac hendrerit imperdiet,                    justo arcu mattis est,                    non ornare urna risus eu quam.Nullam in ultrices nisi,                    vitae ornare nisl.Sed sed pretium nibh.Suspendisse vitae nibh a nisl tincidunt tempor in ac eros.Phasellus placerat tellus sed nulla eleifend,                    eget faucibus urna cursus.Phasellus mauris ipsum,                    facilisis ut leo sit amet,                    volutpat dictum urna.Sed fermentum pretium erat ut fermentum.Duis efficitur eleifend eros vel egestas.Proin tristique accumsan orci vel laoreet.Maecenas eget leo non sem maximus volutpat.Donec non nibh eu elit tincidunt dictum quis a augue.Curabitur sed lacinia leo,                    at vestibulum mi.< br />< br />Fusce scelerisque ex id augue laoreet,                    eget tempor nibh condimentum.Ut rhoncus in nisi aliquet sollicitudin.Aliquam erat volutpat.Morbi egestas lacinia felis id euismod.Ut dapibus justo et arcu egestas,                    vitae condimentum magna scelerisque.Curabitur facilisis,                    odio quis lobortis lacinia,                    tellus mauris venenatis mauris,                    et accumsan ipsum ipsum sit amet odio.Aliquam vel finibus eros.Etiam posuere nunc nec elit elementum,                    ut posuere tortor congue.Sed rhoncus,                    nisl non molestie vestibulum,                    nisl sapien rhoncus tortor,                    at aliquam nisi nisl at nisi.Cras purus magna,                    aliquam quis varius et,                    sagittis et ipsum.Pellentesque faucibus enim a diam malesuada,                    vitae hendrerit mauris eleifend.Lorem ipsum dolor sit amet,                    consectetur adipiscing elit.Nullam in justo felis.Mauris sed accumsan enim,                    quis laoreet eros.Donec euismod est eu rutrum varius.Duis imperdiet justo nec tortor sagittis lobortis.< br />< br />In mattis ac tortor vel ornare.Integer nec risus aliquam eros bibendum interdum.Sed sed pretium ipsum,                    lacinia faucibus diam.Mauris quis leo id odio ultricies consequat.Nam a risus vestibulum,                    fermentum elit eu,                    aliquam mi.Sed quis tortor ut metus feugiat tempus.Integer gravida nisi auctor,                    auctor purus quis,                    convallis leo.Phasellus posuere massa ex,                    sed interdum felis finibus sit amet.Vestibulum efficitur suscipit quam ac tincidunt.Quisque faucibus commodo venenatis.Vestibulum nec dolor posuere,                    viverra justo eu,                    condimentum sem.Suspendisse et sapien vel enim luctus interdum.Nunc non pretium diam.Etiam vehicula,                    neque quis accumsan pulvinar,                    elit orci venenatis justo,                    ac sodales odio justo eget leo."
                });
            }

            return Ok();
        }

    }
}
