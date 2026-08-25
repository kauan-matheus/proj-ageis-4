data "aws_availability_zones" "available" {
  state = "available"
}

resource "aws_vpc" "workstation_vpc" {
  cidr_block           = "10.50.0.0/16"
  enable_dns_support   = true
  enable_dns_hostnames = true

  tags = {
    Name = "workstation-vpc"
  }
}

resource "aws_subnet" "workstation_public" {
  vpc_id                  = aws_vpc.workstation_vpc.id
  cidr_block              = "10.50.1.0/24"
  map_public_ip_on_launch = true
  availability_zone       = data.aws_availability_zones.available.names[0]

  tags = {
    Name = "workstation-public-subnet"
  }
}

resource "aws_internet_gateway" "workstation_igw" {
  vpc_id = aws_vpc.workstation_vpc.id

  tags = {
    Name = "workstation-igw"
  }
}

resource "aws_route_table" "workstation_public" {
  vpc_id = aws_vpc.workstation_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.workstation_igw.id
  }

  tags = {
    Name = "workstation-public-rt"
  }
}

resource "aws_route_table_association" "workstation_public" {
  subnet_id      = aws_subnet.workstation_public.id
  route_table_id = aws_route_table.workstation_public.id
}
