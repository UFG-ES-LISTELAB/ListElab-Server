using System;
using System.Linq;

namespace ListElab.Dominio
{
    public static class FabricaGenerica
    {
        /// <summary>
        /// Cria uma instância da primeira classe que implementa a interface.
        /// </summary>
        /// <typeparam name="IT">A interface que se deseja </typeparam>
        /// <returns></returns>
        public static IT Crie<IT>()
        {
            var type = typeof(IT);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);

            var retorno = Activator.CreateInstance(types.FirstOrDefault());

            return (IT)retorno;
        }
    }
}
