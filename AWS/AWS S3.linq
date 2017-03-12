<Query Kind="Program">
  <NuGetReference>AWSSDK.S3</NuGetReference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.S3</Namespace>
  <Namespace>Amazon.S3.Encryption</Namespace>
  <Namespace>Amazon.S3.Encryption.Internal</Namespace>
  <Namespace>Amazon.S3.Internal</Namespace>
  <Namespace>Amazon.S3.IO</Namespace>
  <Namespace>Amazon.S3.Model</Namespace>
  <Namespace>Amazon.S3.Model.Internal.MarshallTransformations</Namespace>
  <Namespace>Amazon.S3.Transfer</Namespace>
  <Namespace>Amazon.S3.Util</Namespace>
</Query>

void Main()
{
	string accessKey = Util.GetPassword("accessKey");
	string secretAccessKey = Util.GetPassword("secretAccessKey");
	
	var client = new AmazonS3Client(accessKey, secretAccessKey, new AmazonS3Config() { RegionEndpoint = RegionEndpoint.EUCentral1 });
	
	client.ListBuckets().Dump();
}