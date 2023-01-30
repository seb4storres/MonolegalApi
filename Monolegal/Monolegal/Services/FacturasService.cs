using EmailService;
using MongoDB.Driver;
using Monolegal.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Monolegal.Services
{
    public class FacturasService
    {
        private IMongoCollection<Factura> _facturas;

        public FacturasService(IMonolegalDatabaseSettings settings) 
        {
            var cliente = new MongoClient(settings.Server);

            var database = cliente.GetDatabase(settings.Database);

            _facturas = database.GetCollection<Factura>(settings.Collection);
        }

        public List<Factura> Getf()
        {
            return _facturas.Find(x => true).ToList();
        }

        public Factura Create(Factura facturas)
        {
            _facturas.InsertOne(facturas);
            return facturas;
        }

        public void Update(string id, Factura facturas)
        {
            _facturas.ReplaceOne(facturas => facturas.Id==id, facturas);

            
        }

        public void Delete (String id)
        {
            _facturas.DeleteOne(d=>d.Id == id);
        }
        
               
    }
}
