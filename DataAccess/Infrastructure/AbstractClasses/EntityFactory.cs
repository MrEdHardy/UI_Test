﻿using DataAccess.Infrastructure.Interfaces;
using DataAccess.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Infrastructure.Enums;


namespace DataAccess.Infrastructure.AbstractClasses
{
    public abstract class EntityFactory<T> : IEntityFactory<T>
        where T : class
    {
        protected internal Dictionary<string, string> actionPathDefinitions { get; }
        internal abstract JsonSerializerOptions serializerOptions { get; }
        internal Uri pathToController{ get { return this.baseUri; } }
        private Uri baseUri;

        public EntityFactory(Uri baseUri, Dictionary<string, string> paths)
        {
            this.baseUri = baseUri;
            //var controller = string.Empty;
            //if(typeof(T).Equals(typeof(TitleCollectionEntity)))
            //{
            //    controller = "titlecollections/";
            //}
            //else if(typeof(T).Equals(typeof(ArtistCollectionEntity)))
            //{
            //    controller = "artistcollections/";
            //}
            //else
            //{
            //    controller = this.controller;
            //}
            this.actionPathDefinitions = paths;
        }

        public async Task<T> Add(T entity)
        {
            var result = await this.
                AddEntity(this.GetPathToControllerAction(actionPathDefinitions["add"]), entity);
            return result;
        }

        public async Task Delete(int id)
        {
            await this
               .DeleteEntity(this.GetPathToControllerAction(actionPathDefinitions["delete"]), ApiCallType.Id, null, id.ToString());
        }

        public async Task<List<T>> GetAll()
        {
            return await this
                .GetAllEntities(this.GetPathToControllerAction(actionPathDefinitions["getall"]));
        }

        public async Task<List<T>> GetById(int id)
        {
            return await this
                .GetEntityByParam(this.GetPathToControllerAction(actionPathDefinitions["getbyid"]), ApiCallType.Id, id.ToString(), null);
        }

        public async Task Update(int id, T entity)
        {
            await this
                .UpdateEntity(this.GetPathToControllerAction(actionPathDefinitions["update"]), entity, id);
        }
    }
}
