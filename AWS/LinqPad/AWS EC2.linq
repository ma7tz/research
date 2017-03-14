<Query Kind="Program">
  <NuGetReference>AWSSDK.EC2</NuGetReference>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.EC2</Namespace>
  <Namespace>Amazon.EC2.Import</Namespace>
  <Namespace>Amazon.EC2.Internal</Namespace>
  <Namespace>Amazon.EC2.Model</Namespace>
  <Namespace>Amazon.EC2.Model.Internal.MarshallTransformations</Namespace>
  <Namespace>Amazon.EC2.Util</Namespace>
</Query>

void Main()
{
	string accessKey = Util.GetPassword("accessKey");
	string secretAccessKey = Util.GetPassword("secretAccessKey");

	var client = new AmazonEC2Client(accessKey, secretAccessKey, RegionEndpoint.EUCentral1);
	
	client.DescribeInstances().Dump();
	
	client.DescribeImages().Dump();
	
//	var startInstancesRequest = new StartInstancesRequest();
//	
//	client.StartInstances(startInstancesRequest);
}