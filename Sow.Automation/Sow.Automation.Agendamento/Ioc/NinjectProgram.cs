using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Orquestrador.Ioc
{
   public abstract class NinjectProgram
    {
        public NinjectProgram()
        {
            InicializaKernel();
        }
        protected void InicializaKernel()
        {
            Kernel = new StandardKernel();
            Kernel.Load(new ContainerService());
        }

        /// <summary>
        /// Obtem a injeção do Kernel para o programa
        /// </summary>
        protected  IKernel Kernel { get;  set; }

        /// <summary>
        /// Obter o tipo de instancia que será solicitada.
        /// </summary>
        /// <typeparam name="TObject">Tipo da instancia do objeto.</typeparam>
        /// <returns>Retorna uma instancia do objeto</returns>
        protected TObject GetController<TObject>()
           where TObject : class
        {
            return Kernel.Get<TObject>();
        }
    }
}
