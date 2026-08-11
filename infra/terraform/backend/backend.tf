terraform {
    backend "s3" {
        bucket = "terraform-state-bucket"
        key    = "backup/terraform.tfstate"
        region = "us-east-1"
        encrypt = true
    }
}