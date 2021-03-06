﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace KevinsMVCLab.HelperClasses
{
    public static class HelpingClass
    {
        public static bool DoesUserOwnImage(this IIdentity identity, Guid imageId)
        {
            return false;
        }
        public static string GetSid(this IIdentity identity)
        {
            var ident = (ClaimsIdentity)identity;
            var claim = ident.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid);

            var sid = claim.Value;

            return (sid != null) ? claim.Value : string.Empty;
        }


        public static bool IsFilePicture(string filename)
        {
            if (filename.EndsWith(".png") || filename.EndsWith(".PNG"))
            {
                return true;
            }

            if (filename.EndsWith(".jpg") || filename.EndsWith(".JPG"))
            {
                return true;
            }
            if (filename.EndsWith(".jpeg") || filename.EndsWith(".JPEG"))
            {
                return true;
            }

            return false;
        }
    }
}