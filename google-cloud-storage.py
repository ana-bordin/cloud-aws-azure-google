from google.cloud import storage

def create_gcs_bucket(bucket_name):
    client = storage.Client()
    bucket = client.create_bucket(bucket_name)
    
    print(f"Bucket created: {bucket.name}")

# Example usage
create_gcs_bucket('my-unique-bucket-name-1234')