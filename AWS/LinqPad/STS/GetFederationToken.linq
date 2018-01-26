<Query Kind="Program">
  <NuGetReference>AWSSDK.S3</NuGetReference>
  <NuGetReference>AWSSDK.SecurityToken</NuGetReference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.Auth.AccessControlPolicy</Namespace>
  <Namespace>Amazon.Auth.AccessControlPolicy.ActionIdentifiers</Namespace>
  <Namespace>Amazon.Internal</Namespace>
  <Namespace>Amazon.MissingTypes</Namespace>
  <Namespace>Amazon.Runtime</Namespace>
  <Namespace>Amazon.Runtime.CredentialManagement</Namespace>
  <Namespace>Amazon.Runtime.CredentialManagement.Internal</Namespace>
  <Namespace>Amazon.Runtime.Internal</Namespace>
  <Namespace>Amazon.Runtime.Internal.Auth</Namespace>
  <Namespace>Amazon.Runtime.Internal.Settings</Namespace>
  <Namespace>Amazon.Runtime.Internal.Transform</Namespace>
  <Namespace>Amazon.Runtime.Internal.Util</Namespace>
  <Namespace>Amazon.Runtime.SharedInterfaces</Namespace>
  <Namespace>Amazon.Runtime.SharedInterfaces.Internal</Namespace>
  <Namespace>Amazon.SecurityToken</Namespace>
  <Namespace>Amazon.SecurityToken.Model</Namespace>
  <Namespace>Amazon.SecurityToken.Model.Internal.MarshallTransformations</Namespace>
  <Namespace>Amazon.SecurityToken.SAML</Namespace>
  <Namespace>Amazon.Util</Namespace>
  <Namespace>Amazon.Util.Internal</Namespace>
  <Namespace>Amazon.Util.Internal.PlatformServices</Namespace>
  <Namespace>Amazon.S3</Namespace>
</Query>

void Main()
{
	string accessKey = Util.GetPassword("accessKey");
	string secretAccessKey = Util.GetPassword("secretAccessKey");

	var client = new AmazonSecurityTokenServiceClient(accessKey, secretAccessKey, RegionEndpoint.EUCentral1);

	var request = new GetFederationTokenRequest();

	request.DurationSeconds = 1 * 60 * 60;
	request.Policy = @"{
		""Version"": ""2012-10-17"",
    	""Statement"": [
        	{
            	""Effect"": ""Allow"",
            	""Action"": ""s3:*"",
            	""Resource"": ""*""
        	}
    	]
	}";

	request.Name = "name1";

	var response = client.GetFederationToken(request);

	response.Dump();
	
	
	new AmazonS3Client(
		response.Credentials.AccessKeyId, 
		response.Credentials.SecretAccessKey, 
		response.Credentials.SessionToken,
		RegionEndpoint.EUCentral1)
		.ListBuckets().Dump();
}
