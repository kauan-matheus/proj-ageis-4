resource "aws_instance" "ec2-workstation" {
  ami                         = local.ec2_ami
  instance_type               = local.ec2_instance_type
  key_name                    = local.ec2_key_name_workstation
  subnet_id                   = aws_subnet.workstation_public.id
  vpc_security_group_ids      = [aws_security_group.ec2_workstation.id]
  associate_public_ip_address = true

  lifecycle {
    ignore_changes = all
  }

  tags = {
    Name          = "ec2-workstation"
    ProvisionedBy = "Terraform"
    Ciente        = "Kauan"
  }
}
