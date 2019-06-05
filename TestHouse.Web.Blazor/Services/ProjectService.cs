﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestHouse.DTOs.DTOs;
using TestHouse.DTOs.Models;

namespace TestHouse.Web.Blazor.Services
{
    public class ProjectService
    {
        private HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProjectAggregateDto> GetProject(long id)
        {
            Console.WriteLine("getting project");
            var response = await _httpClient.GetAsync("http://localhost:5000/api/project/" + id);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("getting project success");
            var content = await response.Content.ReadAsStringAsync();
            var project = Json.Deserialize<ProjectAggregateDto>(content);
            Console.WriteLine("getting deserialized");

            return project;
        }

        public async Task<List<ProjectDto>> GetProjectsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/api/project/all");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var projects = Json.Deserialize<List<ProjectDto>>(content);

            return projects;
        }

        public async Task<ProjectDto> AddProject(ProjectModel model)
        {
            var content = new StringContent( Json.Serialize(model) , Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5000/api/project", content);
            var result = await response.Content.ReadAsStringAsync();
            return Json.Deserialize<ProjectDto>(result);
        }

        public async Task EditProject(long projectId, ProjectModel model)
        {
            var content = new StringContent(Json.Serialize(model), Encoding.UTF8, "application/json");
            await _httpClient.PatchAsync($"http://localhost:5000/api/project/{projectId}", content);           
        }
    }
}
