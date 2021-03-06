﻿using System;
using System.Collections.Generic;
using PetApiLib.Model;

namespace PetApiLib.Api
{
    /// <summary>
    /// Facade for Pet Api
    /// </summary>
    public class PetApi
    {
        private readonly IRestClientLibrary _restClient;

        public PetApi(string baseUrl)
        {
            if (baseUrl == null) 
                throw new ArgumentNullException(nameof(baseUrl));

            _restClient = new RestClientLibrary(baseUrl);

        }
        /// <summary>
        /// Add Pet
        /// </summary>
        /// <param name="pet">Add a new Pet</param>
        public void AddPet(Pet pet)
        {
            if (pet == null)
                throw new PetApiException(400, "Missing parameter to call AddPet");

            _restClient.Post(pet, "/pet");
        }

        /// <summary>
        /// Find a pet based on 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public Pet GetPetById(in long id)
        {
            return _restClient.Get<Pet>($"/pet/{id}");
        }

        public void DeletePet(long? petId, string specialKey)
        {
            _restClient.AddHeader("api_key", specialKey);
            _restClient.Delete($"/pet/{petId}");
        }

        public List<Pet> FindPetsByTags(List<string> tagToFind)
        {
            string tags = string.Join(",", tagToFind);
            
            return _restClient.Get<List<Pet>>($"/pet/findByTags?tags={tags}");
        }

        public void UpdatePet(Pet pet)
        {
            _restClient.Update<Pet>(pet, "/pet");
        }
    }
}
