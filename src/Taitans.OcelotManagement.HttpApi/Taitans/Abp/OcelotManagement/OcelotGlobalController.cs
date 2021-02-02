﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Taitans.OcelotManagement
{
    [RemoteService(Name = OcelotManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("ocelotManagement")]
    [ControllerName("Ocelot")]
    [Route("/api/ocelot/global-configs")]
    public class OcelotGlobalController : OcelotController, IOcelotAppService
    {
        private readonly IOcelotAppService _ocelotGlobalConfigurationService;

        public OcelotGlobalController(IOcelotAppService ocelotGlobalConfigurationService)
        {
            _ocelotGlobalConfigurationService = ocelotGlobalConfigurationService;
        }

        [HttpPost]
        public async Task<OcelotDto> CreateAsync(OcelotCreateDto input)
        {
            return await _ocelotGlobalConfigurationService.CreateAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _ocelotGlobalConfigurationService.DeleteAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<OcelotDto> GetAsync(Guid id)
        {
            return await _ocelotGlobalConfigurationService.GetAsync(id);
        }

        [HttpGet]
        public async Task<PagedResultDto<OcelotDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await _ocelotGlobalConfigurationService.GetListAsync(input);
        }

        [HttpGet("{id}/re-routes")]
        public async Task<List<OcelotRouteDto>> GetRoutesAsync(Guid id)
        {
            return await _ocelotGlobalConfigurationService.GetRoutesAsync(id);
        }

        [HttpPut("{id}/re-routes")]
        public async Task<List<OcelotRouteDto>> UpdateRoutesAsync(Guid id, List<OcelotRouteDto> input)
        {
            return await _ocelotGlobalConfigurationService.UpdateRoutesAsync(id, input);
        }

        [HttpPut("{id}/reload")]
        public async Task Reload(Guid id)
        {
            await _ocelotGlobalConfigurationService.Reload(id);
        }

        [HttpPut("{id}")]
        public async Task<OcelotDto> UpdateAsync(Guid id, OcelotUpdateDto input)
        {
            return await _ocelotGlobalConfigurationService.UpdateAsync(id, input);
        }
    }
}
