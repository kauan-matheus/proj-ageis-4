resource "aws_instance" "ec2-prod" {
  ami                         = local.ec2_ami
  instance_type               = local.ec2_instance_type
  key_name                    = local.ec2_key_name_prod
  subnet_id                   = aws_subnet.workstation_public.id
  vpc_security_group_ids      = [aws_security_group.ec2_prod.id]
  associate_public_ip_address = true

  tags = {
    Name          = "ec2-prod"
    ProvisionedBy = "Terraform"
    Cliente       = "Kauan"
  }
}