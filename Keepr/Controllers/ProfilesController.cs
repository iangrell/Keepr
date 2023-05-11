using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _profilesService;
        private readonly KeepsService _keepsService;
        private readonly VaultsService _vaultsService;

    public ProfilesController(ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService)
    {
        _profilesService = profilesService;
        _keepsService = keepsService;
        _vaultsService = vaultsService;
    }

    [HttpGet("{profileId}")]
        public ActionResult<Profile> GetProfile(string profileId)
        {
            try
            {
                Profile profile = _profilesService.GetProfile(profileId);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{profileId}/keeps")]
        public ActionResult<List<Keep>> GetProfileKeeps(string profileId)
        {
            try
            {
                List<Keep> keeps = _keepsService.GetProfileKeeps(profileId);
                return Ok(keeps);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{profileId}/vaults")]
        public ActionResult<List<Vault>> GetProfileVaults(string profileId)
        {
            try
            {
                List<Vault> vaults = _vaultsService.GetProfileVaults(profileId);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
