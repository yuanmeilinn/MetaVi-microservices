﻿using Application.Contracts;
using Microsoft.AspNetCore.WebUtilities;
using Storage.Domain.Models;

namespace Storage.API.Application.Commands {
    public class ServiceUploadImageCommand : ICommand<StoredFile> {
        public Guid FileId { get; set; }
        public Guid GroupId { get; set; }
        public string Category { get; set; }
        public MultipartSection ImageSection { get; set; }

        public ServiceUploadImageCommand (Guid fileId, Guid groupId, string category, MultipartSection imageSection) {
            FileId = fileId;
            GroupId = groupId;
            Category = category;
            ImageSection = imageSection;
        }
    }
}
