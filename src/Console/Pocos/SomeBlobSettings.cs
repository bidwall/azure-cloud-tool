using BlobStorage.Contracts;

namespace ConsoleApp.Pocos
{
   public class SomeBlobSettings : IBlobSettings
   {
      public string ConnectionString { get; set; } = "SomeConnectionString";
      public string ContainerName { get; set; } = "SomeContainerName";
      public string DirectoryName { get; set; } = "SomeDirectoryName";
   }
}