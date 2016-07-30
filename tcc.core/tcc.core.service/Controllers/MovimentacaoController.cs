using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using tcc.core.repository.Entity;
using tcc.core.repository.Repositories;
using tcc.core.service.Models;

namespace tcc.core.service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class MovimentacaoController : ApiController
    {
        [HttpGet]
        [Route("api/movimentacao")]
        public Response Get()
        {
            var resp = new Response();

            try
            {
                var movs = new MovimentacaoRepository().GetAll();
                resp.IsSuccess = true;
                resp.Data = movs;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }

        [HttpGet]
        [Route("api/movimentacao/{id}")]
        public Response GetById(int id)
        {
            var resp = new Response();

            try
            {
                var movs = new MovimentacaoRepository().Get(x => x.Id == id);
                resp.Data = movs;
                resp.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }

        [HttpGet]
        [Route("api/movimentacao/status/{statusId}")]
        public Response GetStatus(int statusId)
        {
            var resp = new Response();

            try
            {
                var movs = new MovimentacaoRepository().Get(x => x.StatusMovimentacaoId == statusId);
                resp.Data = movs;
                resp.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }

        [HttpPost]
        [Route("api/movimentacao")]
        public Response Post([FromBody]Movimentacao mov)
        {
            var resp = new Response();

            try
            {
                var rep = new MovimentacaoRepository();

                if (mov.Id == 0)
                    rep.Create(mov);
                else
                    rep.Update(mov);
                
                resp.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }

        [HttpPost]
        [Route("api/movimentacao/delete/{id}")]
        public Response Delete(int id)
        {
            var resp = new Response();
            var rep = new MovimentacaoRepository();

            try
            {
                var mov = rep.Get(x => x.Id == id);

                if (mov == null || mov.Count == 0)
                    throw new Exception("not found");
                
                rep.Remove(mov[0]);

                resp.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }

        [HttpPost]
        [Route("api/movimentacao/aprovar/{id}")]
        public Response Aprovar(int id)
        {
            return AtualizarStatus(id, (int)Status.Movimentacao.Aprovado);
        }

        [HttpPost]
        [Route("api/movimentacao/reprovar/{id}")]
        public Response Reprovar(int id)
        {
            return AtualizarStatus(id, (int)Status.Movimentacao.Reprovado);
        }

        [HttpGet]
        [Route("api/movimentacao/status/counts")]
        public Response StatusCounts()
        {
            var resp = new Response();

            try
            {
                resp.Data = new MovimentacaoRepository().getCountStatusMovimentacao();
                resp.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Response AtualizarStatus(int id, int statusId)
        {
            var resp = new Response();

            try
            {
                var movRep = new MovimentacaoRepository();
                var item = movRep.Get(x => x.Id == id);

                if (item == null || item.Count == 0)
                    throw new Exception("not found");

                item[0].StatusMovimentacaoId = statusId;
                movRep.Update(item[0]);

                resp.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resp = ExceptionHandler.handle(ex);
            }

            return resp;
        }
    }
}