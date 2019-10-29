﻿using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListElab.Dominio.Abstrato
{
    public abstract class ObjetoComId
    {
        public ObjetoComId()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// O id do objeto.
        /// </summary>
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Código que representa o conceito.
        /// </summary>
        [JsonIgnore]
        public int Codigo { get; set; }

        /// <summary>
        /// Sobrescreve o método de hashcode para buscar pelo id.
        /// </summary>
        /// <returns>Retorna o hashcode do id do objeto.</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Sobreescreve o método Equals para comparar objetos pelo id.
        /// </summary>
        /// <param name="obj">Objeto a se comparado.</param>
        /// <returns>Retorna se os objetos são iguais ou não.</returns>
        public override bool Equals(object obj)
        {
            return obj is ObjetoComId objeto && Id == objeto.Id;
        }
    }
}
