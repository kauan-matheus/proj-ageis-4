terraform {
  backend "s3" {
    bucket  = "proj-ageis-4-terraform-state-054020241217"
    key     = "backup/terraform.tfstate"
    region  = "us-east-1"
    encrypt = true
  }
}
