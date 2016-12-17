﻿using System;
using Autofac;
using Client;
using Fibertest.Datacenter.Web;
using Logic.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.Testing;
using Serilog;

namespace Web.Tests
{
    public sealed class ClientServerPair : IDisposable
    {
        private readonly TestServer _server;
        public TypedClient Client { get; }

        public ClientServerPair()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacWeb>();
            builder.RegisterInstance<ILogger>(
                new LoggerConfiguration()
                    .WriteTo.LiterateConsole()
                    .CreateLogger());
            builder.RegisterInstance(GetOptions()).SingleInstance();
            var startup = new Startup(builder.Build());
            _server = TestServer.Create(startup.Configuration);
            Client = new TypedClient(_server.HttpClient);
        }
        private static DbContextOptions<GraphContext> GetOptions()
        {
            var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
            inMemorySqlite.Open();
            var optionsBuilder = new DbContextOptionsBuilder<GraphContext>();
            optionsBuilder.UseSqlite(inMemorySqlite);
            var options = optionsBuilder.Options;
            using (var ctx = new GraphContext(options))
                ctx.Database.EnsureCreated();
            return options;
        }


        public void Dispose() => _server.Dispose();
    }
}