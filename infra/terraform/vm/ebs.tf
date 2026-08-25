resource "aws_ebs_volume" "homolog_data" {
  availability_zone = aws_instance.ec2-homolog.availability_zone
  size              = 20
  type              = "gp3"
  encrypted         = true

  tags = {
    Name          = "ec2-homolog-ebs-20gb"
    ProvisionedBy = "Terraform"
    Cliente       = "Kauan"
  }
}

resource "aws_volume_attachment" "homolog_data" {
  device_name = "/dev/sdf"
  volume_id   = aws_ebs_volume.homolog_data.id
  instance_id = aws_instance.ec2-homolog.id
}

resource "aws_ebs_volume" "prod_data" {
  availability_zone = aws_instance.ec2-prod.availability_zone
  size              = 20
  type              = "gp3"
  encrypted         = true

  tags = {
    Name          = "ec2-prod-ebs-20gb"
    ProvisionedBy = "Terraform"
    Cliente       = "Kauan"
  }
}

resource "aws_volume_attachment" "prod_data" {
  device_name = "/dev/sdg"
  volume_id   = aws_ebs_volume.prod_data.id
  instance_id = aws_instance.ec2-prod.id
}
