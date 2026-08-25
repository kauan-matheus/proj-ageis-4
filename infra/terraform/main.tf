module "vm" {
  source           = "./vm"
  ssh_allowed_cidr = var.ssh_allowed_cidr
}