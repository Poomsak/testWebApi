using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using WebApiTest2r.Models;

namespace WebApiTest2r.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private static  List<ModelStuden> listStuden = new List<ModelStuden>();
        private static  List<ModelTeacher> listTeacher = new List<ModelTeacher>();
        private static  List<ModelClass> listClassRoom = new List<ModelClass>();
        public TestController(){}

        [HttpGet]
        [Route("GetDataStudenAll")]
        public List<ModelStuden> GetDataStudenAll(){
            return listStuden;
        }

        
        [HttpGet]
        [Route("GetDataStudenByID/{id}")]
        public  ModelStuden GetDataStudenByID(string id){
            return listStuden.Find(t => t.StudenID == id);
        }
       
        [HttpPost]
        [Route("AddDataStuden")]
        public void AddDataStuden(String name,int age,String tell) {
           ModelStuden lists_t = new ModelStuden();
           lists_t.StudenID =  Guid.NewGuid().ToString();
           lists_t.StudenName = name;
           lists_t.StudenAge = age;
           lists_t.StudenPhon = tell;

            listStuden.Add(lists_t);
        }   
        [HttpPut]
        [Route("UpdateDataStuden")]
        public bool UpdateDataStuden(ModelStuden item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = listStuden.FindIndex(t => t.StudenID == t.StudenID);
            if (index == -1)
            {
                return false;
            }
            listStuden.RemoveAt(index);
            listStuden.Add(item);
            return true;
        }
        [HttpDelete]
        [Route("DeleteDataStuden/{id}")]
        public void DeleteDataStuden(string id) {
            listStuden.RemoveAll(t => t.StudenID == id);
        }



        //ข้อมูลอาจารย์
        [HttpGet]
        [Route("GetDataTeacherAll")]
        public List<ModelTeacher> GetDataTeacherAll(){
            return listTeacher;
        }

        
        [HttpGet]
        [Route("GetDataTeacherByID/{id}")]
        public  ModelTeacher GetDataTeacherByID(string id){
            return listTeacher.Find(t => t.TeacherId == id);
        }
       
        [HttpPost]
        [Route("AddDataTeacher")]
        public void AddDataTeacher(String name,string tell,String subject) {
           ModelTeacher lists_t = new ModelTeacher();
           lists_t.TeacherId =  Guid.NewGuid().ToString();
           lists_t.TeacherName = name;
           lists_t.TeacherTel = tell;
           lists_t.SubjectTaught = subject;

            listTeacher.Add(lists_t);
        }   
        [HttpPut]
        [Route("UpdateDataTeacher")]
        public bool UpdateDataTeacher(ModelTeacher item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = listTeacher.FindIndex(t => t.TeacherId == t.TeacherId);
            if (index == -1)
            {
                return false;
            }
            listTeacher.RemoveAt(index);
            listTeacher.Add(item);
            return true;
        }
        [HttpDelete]
        [Route("DeleteDataTeacher/{id}")]
        public void DeleteDataTeacher(string id) {
            listTeacher.RemoveAll(t => t.TeacherId == id);
        }


        //ข้อมูลห้องเรียน
        [HttpGet]
        [Route("GetDataClassRoomAll")]
        public List<ModelClass> GetDataClassRoomAll(){
            return listClassRoom;
        }

        
        [HttpGet]
        [Route("GetDataClassRoomID/{id}")]
        public  ModelClass GetDataClassRoomID(string id){
            return listClassRoom.Find(t => t.ClassroomID == id);
        }
       
        [HttpPost]
        [Route("AddDataClassRoom")]
        public void AddDataClassRoom(String name) {
           
           ModelClass lists_t = new ModelClass();
           lists_t.ClassroomID =  Guid.NewGuid().ToString();
           lists_t.ClassroomName = name;
           
            listClassRoom.Add(lists_t);
        }   

        [HttpGet]
        [Route("AddDataClassRoomTeacher")]
        public ModelClass AddDataClassRoomTeacher(string idcallroom,string idteacher) {

           ModelTeacher modelS = listTeacher.Find(t => t.TeacherId == idteacher);
           ModelClass modelC = listClassRoom.Find(t => t.ClassroomID == idcallroom);
           modelC.modelTeacher =  listTeacher.Find(t => t.TeacherId == idteacher);
           int index = listClassRoom.FindIndex(t => t.ClassroomID == t.ClassroomID);
            listClassRoom.RemoveAt(index);
            listClassRoom.Add(modelC);
            return listClassRoom.Find(t => t.ClassroomID == idcallroom);
        }

        [HttpGet]
        [Route("AddDataClassRoomStuden")]
        public ModelClass AddDataClassRoomStuden(string idcallroom,string idstuden) {

           ModelStuden modelS = listStuden.Find(t => t.StudenID == idstuden);
           ModelClass modelC = listClassRoom.Find(t => t.ClassroomID == idcallroom);
           modelC.modelStuden =  listStuden.Find(t => t.StudenID == idstuden);
            int index = listClassRoom.FindIndex(t => t.ClassroomID == t.ClassroomID);
            listClassRoom.RemoveAt(index);
           listClassRoom.Add(modelC);

        return listClassRoom.Find(t => t.ClassroomID == idcallroom);

        }   
         
        [HttpDelete]
        [Route("DeleteDataClassRoom/{id}")]
        public void DeleteDataClassRoom(string id) {
            listClassRoom.RemoveAll(t => t.ClassroomID == id);
        }

    }
}