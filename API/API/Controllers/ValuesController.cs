﻿using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        dbGoTripEntities1 db = new dbGoTripEntities1();
        // GET api/values
        public IQueryable<tblTurPaket> Get()
        {
            return db.tblTurPakets;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            tblTurPaket paket = db.tblTurPakets.FirstOrDefault(i => i.Id == id);
            if (paket == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Id'si {id} olan çalışan bulunamadı.");

            }
            return Request.CreateResponse(HttpStatusCode.OK, paket);

            //return "value";
        }

        // POST api/values
        public HttpResponseMessage Post(tblTurPaket tblTurPaket)
        {
            try
            {
                db.tblTurPakets.Add(tblTurPaket);

                if (db.SaveChanges() > 0)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, tblTurPaket);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + tblTurPaket.Id);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Veri ekleme işlemi yapılamadı.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put([FromBody] int id,[FromUri]tblTurPaket tblTurPaket)
        {
            try
            {
                tblTurPaket tbl = db.tblTurPakets.FirstOrDefault(i => i.Id == id);
                if (tbl == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Tur Paket Id:" + tbl.Id);
                }
                else
                {
                    tbl.Adi = tblTurPaket.Adi;
                    tbl.Fiyat = tblTurPaket.Fiyat;
                    tbl.Sure = tblTurPaket.Sure;
                    tbl.Lokasyon = tblTurPaket.Lokasyon;
                    tbl.Resim = tblTurPaket.Resim;
                    tbl.Detay = tblTurPaket.Detay;
                    if (db.SaveChanges() > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, tblTurPaket);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Güncelleme Yapılamadı");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                tblTurPaket paket = db.tblTurPakets.FirstOrDefault(i => i.Id == id);
                if (paket == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Tur Paket Id:" + id);
                }
                else
                {
                    db.tblTurPakets.Remove(paket);
                    if (db.SaveChanges()>0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Tur Paket Id:" + id);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Kayıt Silinemedi. Tur Paket Id:" + id);

                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
