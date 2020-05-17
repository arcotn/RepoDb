﻿using System;
using System.Data;
using System.Linq.Expressions;

namespace RepoDb
{
    /// <summary>
    /// A class that is used to define a data entity level mappings (ie: Table, Column, Primary, Identity, DB Type and Property Handler).
    /// Use this class if you wish to define the mappings in a fluent manner and avoid the models be decorated by the attributes.
    /// </summary>
    /// <typeparam name="TEntity">The type of the data entity.</typeparam>
    public class EntityMapFluentDefinition<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Creates a new instance of <see cref="EntityMapFluentDefinition{TType}"/> object.
        /// </summary>
        public EntityMapFluentDefinition()
        {
            EntityType = typeof(TEntity);
        }

        #region Properties

        /// <summary>
        /// Gets the current type of the data entity.
        /// </summary>
        public Type EntityType { get; }

        #endregion

        #region Table

        /// <summary>
        /// Defines a mapping between a data entity type and a database object.
        /// </summary>
        /// <param name="databaseObjectName">The name of the database object (ie: Table, View).</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Table(string databaseObjectName) =>
            Table(databaseObjectName, false);

        /// <summary>
        /// Defines a mapping between a data entity type and a database object.
        /// </summary>
        /// <param name="databaseObjectName">The name of the database object (ie: Table, View).</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Table(string databaseObjectName,
            bool force)
        {
            ClassMapper.Add<TEntity>(databaseObjectName, force);
            return this;
        }

        #endregion

        #region Column

        /*
         * Expression
         */

        /// <summary>
        /// Defines a mapping between a data entity type property and a database column.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="columnName">The name of the database column.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Column(Expression<Func<TEntity, object>> expression,
            string columnName) =>
            Column(expression, columnName, false);

        /// <summary>
        /// Defines a mapping between a data entity type property and a database column.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="columnName">The name of the database column.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Column(Expression<Func<TEntity, object>> expression,
            string columnName,
            bool force)
        {
            PropertyMapper.Add<TEntity>(expression, columnName, force);
            return this;
        }

        /*
         * PropertyName
         */

        /// <summary>
        /// Defines a mapping between a data entity type property and a database column (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="columnName">The name of the database column.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Column(string propertyName,
            string columnName) =>
            Column(propertyName, columnName, false);

        /// <summary>
        /// Defines a mapping between a data entity type property and a database column (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="columnName">The name of the database column.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Column(string propertyName,
            string columnName,
            bool force)
        {
            PropertyMapper.Add<TEntity>(propertyName, columnName, force);
            return this;
        }

        /*
         * Field
         */

        /// <summary>
        /// Defines a mapping between a data entity type property and a database column (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="columnName">The name of the database column.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Column(Field field,
            string columnName) =>
            Column(field, columnName, false);

        /// <summary>
        /// Defines a mapping between a data entity type property and a database column (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="columnName">The name of the database column.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Column(Field field,
            string columnName,
            bool force)
        {
            PropertyMapper.Add<TEntity>(field, columnName, force);
            return this;
        }

        #endregion

        #region Primary

        /*
         * Expression
         */

        /// <summary>
        /// Defines the data entity type primary property.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Primary(Expression<Func<TEntity, object>> expression) =>
            Primary(expression, false);

        /// <summary>
        /// Defines the data entity type primary property.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Primary(Expression<Func<TEntity, object>> expression,
            bool force)
        {
            PrimaryMapper.Add<TEntity>(expression, force);
            return this;
        }

        /*
         * PropertyName
         */

        /// <summary>
        /// Defines the data entity type primary property (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Primary(string propertyName) =>
            Primary(propertyName, false);

        /// <summary>
        /// Defines the data entity type primary property (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Primary(string propertyName,
            bool force)
        {
            PrimaryMapper.Add<TEntity>(propertyName, force);
            return this;
        }

        /*
         * Field
         */

        /// <summary>
        /// Defines the data entity type primary property (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Primary(Field field) =>
            Primary(field, false);

        /// <summary>
        /// Defines the data entity type primary property (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Primary(Field field,
            bool force)
        {
            PrimaryMapper.Add<TEntity>(field, force);
            return this;
        }

        #endregion

        #region Identity

        /*
         * Expression
         */

        /// <summary>
        /// Defines the data entity type identity property.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Identity(Expression<Func<TEntity, object>> expression) =>
            Identity(expression, false);

        /// <summary>
        /// Defines the data entity type identity property.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Identity(Expression<Func<TEntity, object>> expression,
            bool force)
        {
            IdentityMapper.Add<TEntity>(expression, force);
            return this;
        }

        /*
         * PropertyName
         */

        /// <summary>
        /// Defines the data entity type identity property (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Identity(string propertyName) =>
            Identity(propertyName, false);

        /// <summary>
        /// Defines the data entity type identity property (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Identity(string propertyName,
            bool force)
        {
            IdentityMapper.Add<TEntity>(propertyName, force);
            return this;
        }

        /*
         * Field
         */

        /// <summary>
        /// Defines the data entity type identity property (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Identity(Field field) =>
            Identity(field, false);

        /// <summary>
        /// Defines the data entity type identity property (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> Identity(Field field,
            bool force)
        {
            IdentityMapper.Add<TEntity>(field, force);
            return this;
        }

        #endregion

        #region DbType

        /*
         * Expression
         */

        /// <summary>
        /// Defines a mapping between a data entity type property and a <see cref="System.Data.DbType"/> object.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="dbType">The target database type.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> DbType(Expression<Func<TEntity, object>> expression,
            DbType? dbType) =>
            DbType(expression, dbType, false);

        /// <summary>
        /// Defines a mapping between a data entity type property and a <see cref="System.Data.DbType"/> object.
        /// </summary>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="dbType">The target database type.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> DbType(Expression<Func<TEntity, object>> expression,
            DbType? dbType,
            bool force)
        {
            TypeMapper.Add<TEntity>(expression, dbType, force);
            return this;
        }

        /*
         * PropertyName
         */

        /// <summary>
        /// Adds a mapping between a class property and database type (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="dbType">The target database type.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> DbType(string propertyName,
            DbType? dbType) =>
            DbType(propertyName, dbType, false);

        /// <summary>
        /// Adds a mapping between a class property and database type (via property name).
        /// </summary>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="dbType">The target database type.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> DbType(string propertyName,
            DbType? dbType,
            bool force)
        {
            TypeMapper.Add<TEntity>(propertyName, dbType, force);
            return this;
        }

        /*
         * Field
         */

        /// <summary>
        /// Adds a mapping between a class property and database type (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="dbType">The target database type.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> DbType(Field field,
            DbType? dbType) =>
            DbType(field, dbType, false);


        /// <summary>
        /// Adds a mapping between a class property and database type (via <see cref="Field"/> object).
        /// </summary>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="dbType">The target database type.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> DbType(Field field,
            DbType? dbType,
            bool force)
        {
            TypeMapper.Add<TEntity>(field, dbType, force);
            return this;
        }

        #endregion

        #region PropertyHandler

        /*
         * Expression
         */

        /// <summary>
        /// Defines a mapping between a data entity type property and a property handler object. It uses the<see cref="Activator.CreateInstance(Type)"/> method to create the instance of target property handler.
        /// Make sure that the default constructor is available for the property handler, otherwise an exception will be thrown.
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="expression">The expression to be parsed.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(Expression<Func<TEntity, object>> expression) =>
            PropertyHandler<TPropertyHandler>(expression, Activator.CreateInstance<TPropertyHandler>());

        /// <summary>
        /// Defines a mapping between a data entity type property and a property handler object.
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="propertyHandler">The instance of the property handler.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(Expression<Func<TEntity, object>> expression,
            TPropertyHandler propertyHandler) =>
            PropertyHandler<TPropertyHandler>(expression, propertyHandler, false);

        /// <summary>
        /// Defines a mapping between a data entity type property and a property handler object.
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="expression">The expression to be parsed.</param>
        /// <param name="propertyHandler">The instance of the property handler.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(Expression<Func<TEntity, object>> expression,
            TPropertyHandler propertyHandler,
            bool force)
        {
            PropertyHandlerMapper.Add<TEntity, TPropertyHandler>(expression, propertyHandler, force);
            return this;
        }

        /*
         * PropertyName
         */

        /// <summary>
        /// Adds a property handler mapping into a data entity type property (via property name). It uses the<see cref="Activator.CreateInstance(Type)"/> method to create the instance of target property handler.
        /// Make sure that the default constructor is available for the property handler, otherwise an exception will be thrown.
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(string propertyName) =>
            PropertyHandler<TPropertyHandler>(propertyName, Activator.CreateInstance<TPropertyHandler>(), false);

        /// <summary>
        /// Adds a property handler mapping into a data entity type property (via property name).
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="propertyHandler">The instance of the property handler.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(string propertyName,
            TPropertyHandler propertyHandler) =>
            PropertyHandler<TPropertyHandler>(propertyName, propertyHandler, false);

        /// <summary>
        /// Adds a property handler mapping into a data entity type property (via property name).
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="propertyName">The name of the class property to be mapped.</param>
        /// <param name="propertyHandler">The instance of the property handler.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(string propertyName,
            TPropertyHandler propertyHandler,
            bool force)
        {
            PropertyHandlerMapper.Add<TEntity, TPropertyHandler>(propertyName, propertyHandler, force);
            return this;
        }

        /*
         * Field
         */

        /// <summary>
        /// Adds a property handler mapping into a data entity type property (via <see cref="Field"/> object). It uses the<see cref="Activator.CreateInstance(Type)"/> method to create the instance of target property handler.
        /// Make sure that the default constructor is available for the property handler, otherwise an exception will be thrown.
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(Field field) =>
            PropertyHandler<TPropertyHandler>(field, Activator.CreateInstance<TPropertyHandler>(), false);

        /// <summary>
        /// Adds a property handler mapping into a data entity type property (via <see cref="Field"/> object).
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="propertyHandler">The instance of the property handler.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(Field field,
            TPropertyHandler propertyHandler) =>
            PropertyHandler<TPropertyHandler>(field, propertyHandler, false);

        /// <summary>
        /// Adds a property handler mapping into a data entity type property (via <see cref="Field"/> object).
        /// </summary>
        /// <typeparam name="TPropertyHandler">The type of the property handler.</typeparam>
        /// <param name="field">The instance of <see cref="Field"/> to be mapped.</param>
        /// <param name="propertyHandler">The instance of the property handler.</param>
        /// <param name="force">A value that indicates whether to force the mapping. If one is already exists, then it will be overwritten.</param>
        /// <returns>The current instance.</returns>
        public EntityMapFluentDefinition<TEntity> PropertyHandler<TPropertyHandler>(Field field,
            TPropertyHandler propertyHandler,
            bool force)
        {
            PropertyHandlerMapper.Add<TEntity, TPropertyHandler>(field, propertyHandler, force);
            return this;
        }

        #endregion
    }
}