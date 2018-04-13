using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    public class OpcionesController : ApiController
    {
        private TriviaContext db = new TriviaContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }


        public IEnumerable<TriviaOption> GetAll() {
            var triviaOptions = db.TriviaOptions.Select(t => t).ToList();
            return triviaOptions;
        }
        public TriviaOption GetById(int id, bool correct = true) {
            var triviaOption = db.TriviaOptions.FirstOrDefault(t => t.QuestionId == id && t.IsCorrect == correct);
            return triviaOption;
        }

        //http://localhost:57978/api/root/?name=jhon alexander puin vargas
        //http://localhost:57978/api/opciones/?name=jhon alexander puin vargas
        //http://localhost:57978/api/opciones/FindTriviaOptionByName/?name=jhon alexander puin vargas
        [HttpGet]
        public void FindTriviaOptionByName(string name) {
            var triviaOption = db.TriviaOptions.FirstOrDefault(t => t.Title.Contains(name));
        }

        public void Post(TriviaOption value) {
            var ingreso = true;
        }
        public void Put(int id, TriviaOption value) {
            var ingreso = true;
        }
        public void Put(TriviaOption value)
        {
            var ingreso = true;
        }
    }
}
