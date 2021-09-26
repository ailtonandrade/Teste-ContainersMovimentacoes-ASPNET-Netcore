using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using projetop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetop.Controllers
{
    [EnableCors("cors")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        MovimentacoesRepository movimentacoesrepository = new MovimentacoesRepository();

        [HttpGet]
        [Route("/home")]
        //getall
        public string Index()
        {

            return movimentacoesrepository.getall();
        }
        //get
        [HttpGet]
        [Route("/details")]
        //getall
        public string details(int id)
        {

            return movimentacoesrepository.details(id);
        }
        //get
        [HttpGet]
        [Route("/movtype")]
        //getall
        public string tipomovimentacao(string mov)
        {
           
            return movimentacoesrepository.tipomovimentacao(mov);
        }
        //save
        [HttpPost]
        [Route("/save")]
        public void save(string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            movimentacoesrepository.save(clientecontainer, numerocontainer, tipocontainer, statuscontainer, categoriacontainer, tipomovimentacao, iniciomovimentacao, fimmovimentacao);
        }
        //update
        [HttpPut]
        [Route("/update")]
        public void update(int idcontainer, int idmov, string clientecontainer, string numerocontainer, string tipocontainer, string statuscontainer, string categoriacontainer, string tipomovimentacao, string iniciomovimentacao, string fimmovimentacao)
        {
            movimentacoesrepository.update(idcontainer, idmov, clientecontainer, numerocontainer, tipocontainer, statuscontainer, categoriacontainer, tipomovimentacao, iniciomovimentacao, fimmovimentacao);
        }
        //deletar
        [HttpDelete]
        [Route("/deletar")]
        public void deletar(int id)
        {
            movimentacoesrepository.deletar(id);
        }
    }
}
