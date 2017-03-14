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
	
	var runInstancesRequest = new RunInstancesRequest("ami-af0fc0c0", 1, 1)
	{
		InstanceType = InstanceType.T2Micro
	};
	
	var runInstancesResponse = client.RunInstances(runInstancesRequest);
	
	runInstancesResponse.Dump();

	var describeInstancesResponse = client.DescribeInstances();
	
	describeInstancesResponse.Dump();
	
	var terminateInstancesRequest = new TerminateInstancesRequest(runInstancesResponse.Reservation.Instances.Select(i => i.InstanceId).ToList());

	client.TerminateInstances(terminateInstancesRequest);
}