using System;
using System.Collections.Generic;
using NUnit.Framework;
using PetApiLib.Api;
using PetApiLib.Model;
using PetStoreTest.Tools;

namespace PetStoreTest.Tests
{
    public class PetTests
    {
        private PetApi _petApi;

        [SetUp]
        public void Setup()
        {
            this._petApi = new PetApi();
        }

        [Test]
        public void AddNewPetTest()
        {
            long id = DateTime.Now.Ticks;
            Category category = new Category(id, StringTools.GenerateRandomString("Dog", 16));
            List<string> photoUrls = new List<string>() { StringTools.GenerateRandomString("Dog", 16) };
            List<Tag> tags = new List<Tag>() { new Tag(id, StringTools.GenerateRandomString("LastName", 16)) };
            Pet pet = new Pet(id, category, StringTools.GenerateRandomString("Kaiser", 16), photoUrls, tags, Pet.StatusEnum.Available);
            this._petApi.AddPet(pet);

            Pet recoverPet = this._petApi.GetPetById(id);
            Assert.AreEqual(pet, recoverPet);
        }

        [Test]
        public void ReadPetTest()
        {
            long id = DateTime.Now.Ticks;
            Category category = new Category(id, StringTools.GenerateRandomString("Dog", 16));
            List<string> photoUrls = new List<string>() { "https://www.google.com" };
            List<Tag> tags = new List<Tag>() { new Tag(id, StringTools.GenerateRandomString("Tags", 16)) };
            Pet pet = new Pet(id, category, StringTools.GenerateRandomString("Kaiser", 16), photoUrls, tags, Pet.StatusEnum.Available);
            this._petApi.AddPet(pet);

            // Read Pet
            Pet recoverPet = this._petApi.GetPetById(id);
            
            Assert.AreEqual(pet, recoverPet);
        }

        [Test]
        public void UpdatePetTest()
        {
            long id = DateTime.Now.Ticks;

            // Create PET
            Category category = new Category(id, StringTools.GenerateRandomString("Dog", 16));
            List<string> photoUrls = new List<string>() { "https://www.microsoft.com" };
            List<Tag> tags = new List<Tag>() { new Tag(id, StringTools.GenerateRandomString("Canine", 16)) };
            Pet pet = new Pet(id, category, StringTools.GenerateRandomString("Kaiser", 16), photoUrls, tags, Pet.StatusEnum.Available);
            this._petApi.AddPet(pet);

            // Update pet
            long newId = DateTime.Now.Ticks;
            pet.Category = new Category(newId, StringTools.GenerateRandomString("BigDog", 16));
            this._petApi.UpdatePet(pet);


            // Read Pet
            Pet recoverPet = this._petApi.GetPetById(id);

            // Assert Pet
            Assert.AreEqual(pet.Category.Id, recoverPet.Category.Id);
            Assert.AreEqual(pet, recoverPet);
        }

        [Test]
        public void DeletePetTest()
        {
            long id = DateTime.Now.Ticks;
            // Create PET
            Category category = new Category(id, StringTools.GenerateRandomString("BigDog", 16));
            List<string> photoUrls = new List<string>() { $"https://{StringTools.GenerateRandomString("www", 16)}" };
            List<Tag> tags = new List<Tag>() { new Tag(id, "YouCanDelete") };
            Pet pet = new Pet(id, category, "Meow", photoUrls, tags, Pet.StatusEnum.Available);
            this._petApi.AddPet(pet);

            // Update pet
            this._petApi.DeletePet(pet.Id, "special-key");


            // Read Pet
            List<string> tagToFind = new List<string>() { StringTools.GenerateRandomString("YouCanDelete", 16) };
            List<Pet> recoverPets = this._petApi.FindPetsByTags(tagToFind);

            // Assert Pet
            Assert.AreEqual(recoverPets.Count, 0);
        }
    }
}