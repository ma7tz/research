<Query Kind="Statements">
  <NuGetReference>AWSSDK.SQS</NuGetReference>
  <Namespace>Amazon.SQS</Namespace>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.SQS.Model</Namespace>
</Query>

var aws_access_key_id = Util.GetPassword("aws_access_key_id");
var aws_secret_access_key = Util.GetPassword("aws_secret_access_key");

var client = new AmazonSQSClient(aws_access_key_id, aws_secret_access_key, RegionEndpoint.EUCentral1);

var request = new SendMessageRequest
{
	QueueUrl = Util.LoadString("queueUrl"),
	MessageBody = "Hello SQS!"
};

request.Dump();

var response = client.SendMessage(request);

response.Dump();
