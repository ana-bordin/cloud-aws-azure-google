import boto3

def create_s3_bucket(bucket_name, region='us-west-2'):
    s3 = boto3.client('s3', region_name=region)
    
    # Create the S3 bucket
    response = s3.create_bucket(
        Bucket=bucket_name,
        CreateBucketConfiguration={
            'LocationConstraint': region
        }
    )
    
    print(f"Bucket created: {response['Location']}")

# Example usage
create_s3_bucket('my-unique-bucket-name-1234')