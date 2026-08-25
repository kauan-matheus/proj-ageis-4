resource "aws_instance" "ec2-homolog" {
  ami                         = local.ec2_ami
  instance_type               = local.ec2_instance_type
  key_name                    = local.ec2_key_name_homolog
  subnet_id                   = aws_subnet.workstation_public.id
  vpc_security_group_ids      = [aws_security_group.ec2_homolog.id]
  associate_public_ip_address = true

  tags = {
    Name          = "ec2-homolog"
    ProvisionedBy = "Terraform"
    Cliente       = "Kauan"
  }
}