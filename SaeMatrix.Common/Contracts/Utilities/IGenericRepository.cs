﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace SAE.Matrix.Common.Contracts.Utilities
{
    using Entities;

    public interface IGenericRepository<TEntity, TContext>
            where TEntity : class
            where TContext : DbContext
    {
        #region C - Create

        /// <summary>
        /// Metodo encargado de insertar un registro del Tipo T en BD
        /// </summary>
        /// <param name="entity">Entidad a procesar</param>
        /// <returns>Entidad procesada</returns>
        Task<TEntity> Create(TEntity entity);

        #endregion

        #region R - Read

        /// <summary>
        /// Lee todos los registros de la entidad
        /// </summary>
        /// <returns>Listado de registros de la entidad</returns>
        Task<List<TEntity>> ReadAll();

        /// <summary>
        /// Lee todos los registros de la entidad con paginación
        /// </summary>
        /// <param name="orderBy">Funcion que determina el ordenador para la paginación</param>
        /// <param name="page">Pagina</param>
        /// <param name="size">Tamaño de la pagina</param>
        /// <returns>Objeto con el resultado de la consulta</returns>
        Task<PagedResult<TEntity>> Read(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page = 0, int size = 0);

        /// <summary>
        /// Lee todos los registros con la capacidad de incluir entidades relacionadas en BD, incluyendo paginación
        /// </summary>
        /// <param name="expression">Expresion que representa el filtro de la entidad</param>
        /// <param name="include">Funcion que determina las entidades que se relacionan con la entidad</param>
        /// <param name="orderBy">Funcion que determina el ordenador para la paginación</param>
        /// <param name="page">Pagina</param>
        /// <param name="size">Tamaño de la pagina</param>
        /// <returns>Objeto con el resultado de la consulta</returns>
        Task<PagedResult<TEntity>> Read(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int page = 0, int size = 0);

        /// <summary>
        /// Filtra y lista los registros de una entidad sin paginar.
        /// </summary>
        /// <param name="expression">Expresion que representa el filtro de la entidad</param>
        /// <returns>Listado de registros de la entidad</returns>
        Task<List<TEntity>> Read(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Filtra y obtiene el total de los registros de una entidad sin paginar.
        /// </summary>
        /// <param name="expression">Expresion que representa el filtro de la entidad</param>
        /// <returns>Total de registros de la entidad</returns>
        int ReadCount(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Filtra y lista un registro de una entidad sin paginar.
        /// </summary>
        /// <param name="expression">Expresion que representa el filtro de la entidad</param>
        /// <returns>El primer registro de la entidad que concuerde con los criterio o null</returns>
        Task<PagedOneResult<TEntity>> ReadOne(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Filtra y lista un registro de una entidad, permitiendo ordenar.
        /// </summary>
        /// <param name="expression">Expresion que representa el filtro de la entidad</param>
        ///  /// <param name="orderBy">Funcion que determina el ordenador para la paginación</param>
        /// <returns>El primer registro de la entidad que concuerde con los criterio o null</returns>
        Task<PagedOneResult<TEntity>> ReadOne(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        #endregion

        #region U - Update

        /// <summary>
        /// Metodo que actualiza la entidad con la informacion suministrada
        /// </summary>
        /// <param name="entity">Entidad procesada</param>
        /// <returns>True/False</returns>
        Task<bool> Update(TEntity entity);

        #endregion

        #region D - Delete

        /// <summary>
        /// Metodo encargado de eliminar entidades a partir de un filtro
        /// </summary>
        /// <param name="expression">Expresion que representa el filtro de la entidad</param>
        /// <returns>true/false</returns>
        Task<bool> Delete(IEnumerable<TEntity> data);

        #endregion
    }
}